using Generic.Entities.Data;
using Generic.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authentication;

using System.Text;
using Generic.Repository.Interface;

namespace Generic.Controllers
{
    public class LoginController : Controller
    {
        private readonly CIIContext _db;
        private readonly IRepository<SkillViewModel> _skillRepository;


        public LoginController(CIIContext db, IRepository<SkillViewModel> skillRepository)
        {
            _db = db;
            _skillRepository = skillRepository;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            
            var status = _db.Users.Where(m => m.Email == model.Email && m.Password == model.Password).FirstOrDefault();

            if (status == null)
            {
                ViewBag.Notification = "Wrong Username Or Password.";
            }
            else
            {
                HttpContext.Session.SetString("UserName", status.FirstName + " " + status.LastName);
                HttpContext.Session.SetInt32("userid", (int)status.UserId);
                HttpContext.Session.SetString("Avtar", status.Avatar);

                return RedirectToAction("Skill");
            }

            return View(model);

        }


        //skill tab

        [HttpPost]
        public IActionResult Skill()
        {
            ViewBag.user = HttpContext.Session.GetString("UserName");
            ViewBag.Avtar = HttpContext.Session.GetString("Avtar");

            var userId = (int)HttpContext.Session.GetInt32("userid");
            ViewBag.uid = userId;

            //SkillViewModel sv = new SkillViewModel();
           
            //sv.skills = _db.Skills.ToList();
            //return View(sv);

            var skills = _skillRepository.GetAll();
            return View(skills);
        }

    }
}
