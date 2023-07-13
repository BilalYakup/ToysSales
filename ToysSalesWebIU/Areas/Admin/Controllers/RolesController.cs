using Business.Dtos.Roles;
using Data.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ToysSalesWebIU.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "admin")]
	public class RolesController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public RolesController(UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager)
		{
			_userManager = userManager;
			_roleManager = roleManager;
		}
		public IActionResult Index()
		{
			var roles = _roleManager.Roles;
			return View(roles);
		}

		[HttpGet]
		public IActionResult CreateRole() 
		{
			return View();
		}

		[HttpPost,ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateRole(CreateRoleDTO model)
		{
			if (ModelState.IsValid)
			{
				IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(model.Name));

				if (result.Succeeded)
				{
					TempData["Success"] = "Rol Kaydedildi";
					return RedirectToAction("Index");
				}
				else 
				{
					foreach (IdentityError error in result.Errors)
					{
						ModelState.AddModelError("", error.Description);
					}
				}
			}

			TempData["Error"] = "Rol Kaydedilemedi";
			return View(model);

		}

		[HttpGet]
		public async Task<IActionResult> AssignedUser(string id)
		{
			IdentityRole role =await _roleManager.FindByIdAsync(id);

			List<AppUser> hasRole= new List<AppUser>();
			List<AppUser> hasNotRole = new List<AppUser>();

			foreach (AppUser user in _userManager.Users)
			{
				var list = await _userManager.IsInRoleAsync(user, role.Name) ? hasRole : hasNotRole;
				list.Add(user);
			}

			AssignedUserDTO model = new AssignedUserDTO()
			{
				Role = role,
				HasRole = hasRole,
				HasNotRole = hasNotRole,
				RoleName = role.Name,
			};
			return View(model);
		}

		[HttpPost,ValidateAntiForgeryToken]
		public async Task<IActionResult> AssignedUser(AssignedUserDTO model)
		{
			IdentityResult result;
			foreach (var userId in model.AddIds ?? new string[] {})
			{
				AppUser user = await _userManager.FindByIdAsync(userId);
				result = await _userManager.AddToRoleAsync(user, model.RoleName);
			}
			foreach (var userId in model.DeleteIds ?? new string[] { })
			{
				AppUser user = await _userManager.FindByIdAsync(userId);
				result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);
			}

			return RedirectToAction("Index");
		}

		public async Task<IActionResult> DeleteRole(string id) 
		{
			var role =await _roleManager.FindByIdAsync(id);

			IdentityResult result=await _roleManager.DeleteAsync(role);

			if (result.Succeeded)
			{
				TempData["Succuess"] = "Role Silindi";
			}
			foreach (IdentityError error in result.Errors)
			{
				ModelState.AddModelError("", error.Description);
				TempData["error"] = error.Description;
			}
			return RedirectToAction("index");
		}
	}
}
