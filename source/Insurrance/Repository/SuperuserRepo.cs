using Insurrance.Models;
using Insurrance.Models.Entities;
using Insurrance.Models.ViewModels;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Transactions;
namespace Insurrance.Repository
{
    public class SuperuserRepo
    {
        private GenericRepository<Superuser> context = null;
        private ApplicationUserManager UserManager = null;

        public SuperuserRepo(GenericRepository<Superuser> _context, ApplicationUserManager _userManager)
        {
            context = _context;
            UserManager = _userManager;
        }

        public SuperuserRepo(GenericRepository<Superuser> _context)
        {
            context = _context;
        }

        public SuperuserRepo()
        {
            context = new GenericRepository<Superuser>();
        }

        public IEnumerable<Superuser> Get()
        {
            return context.GetAll();
        }

        public Superuser Create(UserAdd model)
        {
            Superuser data = null;
            using (var scope = new TransactionScope())
            {
                var user = new ApplicationUser { UserName = model.Username, Email = model.Email };
                var result = UserManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    UserManager.AddToRole(UserManager.FindByName(user.UserName).Id, "Superuser");
                    data = context.Insert(new Superuser
                     {
                         Username = model.Username,
                         SuperuserId = model.Id,
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