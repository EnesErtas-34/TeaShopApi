using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaShopApi.EntityLayer.Concrete;

namespace TeaShopApi.DataAccessLayer.Context
{
    public class TeaContext:IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-RO7ES1P;initial Catalog=TeaShopDb;integrated Security=true;");
        }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Question> Questions  { get; set; }
        public DbSet<Testimonial> Testimonials  { get; set; }
        public DbSet<About> Abouts  { get; set; }
        public DbSet<Subscribe> Subscribes  { get; set; }
    }
}
