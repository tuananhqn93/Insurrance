using Insurrance.Models;
using Insurrance.Models.Entities;
using Insurrance.Models.ViewModels;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
namespace Insurrance.Repository
{
    public class CallcenterRepo
    {
        private GenericRepository<Callcenter> context = null;
        private ApplicationUserManager UserManager = null;
        private ApplicationSignInManager SignInManager = null;
        public CallcenterRepo(GenericRepository<Callcenter> _context, ApplicationUserManager _userManager, ApplicationSignInManager _signInManager)
        {
            context = _context;
            UserManager = _userManager;
            SignInManager = _signInManager;
        }

        public CallcenterRepo(GenericRepository<Callcenter> _context)
        {
            context = _context;
        }

        public CallcenterRepo()
        {
            context = new GenericRepository<Callcenter>();
        }

        public IEnumerable<Callcenter> Get()
        {
            return context.GetAll();
        }

        public Callcenter Create(UserAdd model)
        {
            Callcenter data = null;
            using (var scope = new TransactionScope())
            {
                var user = new ApplicationUser { UserName = model.Username, Email = model.Email };
                var result = UserManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    UserManager.AddToRole(UserManager.FindByName(user.UserName).Id, "Callcenter");
                    data = context.Insert(new Callcenter
                    {
                        Username = model.Username,
                        CallcenterId = model.Id,
                        SuperuserId = SignInManager.AuthenticationManager.User.Identity.GetUserId(),
                        PostCode = model.PostCode,
                        Phone = model.Phone,
                        NIN = model.NIN,
                        LastName = model.LastName,
                        FirstName = model.FirstName,
                        Email = model.Email,
                        Address = model.Address
                    });
                    context.Save();
                    scope.Complete();
                }
            }
            return data;
        }
    }
}