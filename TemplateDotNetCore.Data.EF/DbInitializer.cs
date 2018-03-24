using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TemplateDotNetCore.Data.Entities;
using TemplateDotNetCore.Data.Enums;

namespace TemplateDotNetCore.Data.EF
{
    public class DbInitializer
    {
        private readonly AppDbContext _context;
        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _roleManager;

        public DbInitializer(AppDbContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Description = "Top manager"
                });
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = "Staff",
                    NormalizedName = "Staff",
                    Description = "Staff"
                });
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = "Customer",
                    NormalizedName = "Customer",
                    Description = "Customer"
                });
            }
            if (!_userManager.Users.Any())
            {
                await _userManager.CreateAsync(new AppUser()
                {
                    UserName = "admin",
                    FullName = "Administrator",
                    Email = "admin@gmail.com",
                    Balance = 0,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    Status = Status.Active
                }, "123654$");
                var user = await _userManager.FindByNameAsync("admin");
                await _userManager.AddToRoleAsync(user, "Admin");

                await _userManager.CreateAsync(new AppUser()
                {
                    UserName = "NamHai",
                    FullName = "Hai Admin",
                    Email = "trannamhaibp@gmail.com",
                    Balance = 0,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    Avatar = "/admin-side/images/avatar/avatarhaiadmin.jpg",
                    Status = Status.Active
                }, "123654$");
                var newuser = await _userManager.FindByNameAsync("NamHai");
                await _userManager.AddToRoleAsync(newuser, "Admin");
            }
            if (_context.Functions.Count() == 0)
            {
                List<Function> functions = new List<Function>()
                {
                    new Function() {Id = "SYSTEM", Name = "System",ParentId = null,SortOrder = 1,Status = Status.Active,URL = "/",IconCss = "fa-desktop"  },
                    new Function() {Id = "ROLE", Name = "Role",ParentId = "SYSTEM",SortOrder = 1,Status = Status.Active,URL = "/admin/role/index",IconCss = "fa-home"  },
                    new Function() {Id = "FUNCTION", Name = "Function",ParentId = "SYSTEM",SortOrder = 2,Status = Status.Active,URL = "/admin/function/index",IconCss = "fa-home"  },
                    new Function() {Id = "USER", Name = "User",ParentId = "SYSTEM",SortOrder =3,Status = Status.Active,URL = "/admin/user/index",IconCss = "fa-home"  },
                    new Function() {Id = "ACTIVITY", Name = "Activity",ParentId = "SYSTEM",SortOrder = 4,Status = Status.Active,URL = "/admin/activity/index",IconCss = "fa-home"  },
                    new Function() {Id = "ERROR", Name = "Error",ParentId = "SYSTEM",SortOrder = 5,Status = Status.Active,URL = "/admin/error/index",IconCss = "fa-home"  },
                    new Function() {Id = "SETTING", Name = "Configuration",ParentId = "SYSTEM",SortOrder = 6,Status = Status.Active,URL = "/admin/setting/index",IconCss = "fa-home"  },

                    new Function() {Id = "PRODUCT",Name = "Product Management",ParentId = null,SortOrder = 2,Status = Status.Active,URL = "/",IconCss = "fa-chevron-down"  },
                    new Function() {Id = "PRODUCT_CATEGORY",Name = "Category",ParentId = "PRODUCT",SortOrder =1,Status = Status.Active,URL = "/admin/productcategory/index",IconCss = "fa-chevron-down"  },
                    new Function() {Id = "PRODUCT_LIST",Name = "Product",ParentId = "PRODUCT",SortOrder = 2,Status = Status.Active,URL = "/admin/product/index",IconCss = "fa-chevron-down"  },
                    new Function() {Id = "BILL",Name = "Bill",ParentId = "PRODUCT",SortOrder = 3,Status = Status.Active,URL = "/admin/bill/index",IconCss = "fa-chevron-down"  },

                    new Function() {Id = "CONTENT",Name = "Content",ParentId = null,SortOrder = 3,Status = Status.Active,URL = "/",IconCss = "fa-table"  },
                    new Function() {Id = "BLOG",Name = "Blog",ParentId = "CONTENT",SortOrder = 1,Status = Status.Active,URL = "/admin/blog/index",IconCss = "fa-table"  },
                    new Function() {Id = "PAGE",Name = "Page",ParentId = "CONTENT",SortOrder = 2,Status = Status.Active,URL = "/admin/page/index",IconCss = "fa-table"  },

                    new Function() {Id = "UTILITY",Name = "Utilities",ParentId = null,SortOrder = 4,Status = Status.Active,URL = "/",IconCss = "fa-clone"  },
                    new Function() {Id = "FOOTER",Name = "Footer",ParentId = "UTILITY",SortOrder = 1,Status = Status.Active,URL = "/admin/footer/index",IconCss = "fa-clone"  },
                    new Function() {Id = "FEEDBACK",Name = "Feedback",ParentId = "UTILITY",SortOrder = 2,Status = Status.Active,URL = "/admin/feedback/index",IconCss = "fa-clone"  },
                    new Function() {Id = "ANNOUNCEMENT",Name = "Announcement",ParentId = "UTILITY",SortOrder = 3,Status = Status.Active,URL = "/admin/announcement/index",IconCss = "fa-clone"  },
                    new Function() {Id = "CONTACT",Name = "Contact",ParentId = "UTILITY",SortOrder = 4,Status = Status.Active,URL = "/admin/contact/index",IconCss = "fa-clone"  },
                    new Function() {Id = "SLIDE",Name = "Slide",ParentId = "UTILITY",SortOrder = 5,Status = Status.Active,URL = "/admin/slide/index",IconCss = "fa-clone"  },
                    new Function() {Id = "ADVERTISMENT",Name = "Advertisment",ParentId = "UTILITY",SortOrder = 6,Status = Status.Active,URL = "/admin/advertistment/index",IconCss = "fa-clone"  },

                    new Function() {Id = "REPORT",Name = "Report",ParentId = null,SortOrder = 5,Status = Status.Active,URL = "/",IconCss = "fa-bar-chart-o"  },
                    new Function() {Id = "REVENUES",Name = "Revenue report",ParentId = "REPORT",SortOrder = 1,Status = Status.Active,URL = "/admin/report/revenues",IconCss = "fa-bar-chart-o"  },
                    new Function() {Id = "ACCESS",Name = "Visitor Report",ParentId = "REPORT",SortOrder = 2,Status = Status.Active,URL = "/admin/report/visitor",IconCss = "fa-bar-chart-o"  },
                    new Function() {Id = "READER",Name = "Reader Report",ParentId = "REPORT",SortOrder = 3,Status = Status.Active,URL = "/admin/report/reader",IconCss = "fa-bar-chart-o"  },
                };
                _context.Functions.AddRange(functions);

            }

            if (_context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
                {
                    new ProductCategory() { Name="Điện thoại",SeoAlias="dien-thoai",ParentId = null,Status=Status.Active,SortOrder=1,
                        Products = new List<Product>()
                        {
                            new Product(){Name = "Điện thoại 1",DateCreated=DateTime.Now,Image="/client-side/images/products/iphone-x.jpg",SeoAlias = "dien-thoai-1",Price = 1000,Status = Status.Active,PromotionPrice = 1100},
                            new Product(){Name = "Điện thoại 2",DateCreated=DateTime.Now,Image="/client-side/images/products/iphone-x.jpg",SeoAlias = "dien-thoai-2",Price = 1000,Status = Status.Active,PromotionPrice = 1100},
                            new Product(){Name = "Điện thoại 3",DateCreated=DateTime.Now,Image="/client-side/images/products/iphone-x.jpg",SeoAlias = "dien-thoai-3",Price = 1000,Status = Status.Active,PromotionPrice = 1100},
                            new Product(){Name = "Điện thoại 4",DateCreated=DateTime.Now,Image="/client-side/images/products/iphone-x.jpg",SeoAlias = "dien-thoai-4",Price = 1000,Status = Status.Active,PromotionPrice = 1100},
                            new Product(){Name = "Điện thoại 5",DateCreated=DateTime.Now,Image="/client-side/images/products/iphone-x.jpg",SeoAlias = "dien-thoai-5",Price = 1000,Status = Status.Active,PromotionPrice = 1100},
                        }
                    },
                    new ProductCategory() { Name="Máy tính bảng",SeoAlias="may-tinh-bang",ParentId = null,Status=Status.Active ,SortOrder=2,
                        Products = new List<Product>()
                        {
                            new Product(){Name = "Máy tính bảng 1",DateCreated=DateTime.Now,Image="/client-side/images/products/iphone-x.jpg",SeoAlias = "may-tinh-bang-1",Price = 1000,Status = Status.Active,PromotionPrice = 1100},
                            new Product(){Name = "Máy tính bảng 2",DateCreated=DateTime.Now,Image="/client-side/images/products/iphone-x.jpg",SeoAlias = "may-tinh-bang-2",Price = 1000,Status = Status.Active,PromotionPrice = 1100},
                            new Product(){Name = "Máy tính bảng 3",DateCreated=DateTime.Now,Image="/client-side/images/products/iphone-x.jpg",SeoAlias = "may-tinh-bang-3",Price = 1000,Status = Status.Active,PromotionPrice = 1100},
                            new Product(){Name = "Máy tính bảng 4",DateCreated=DateTime.Now,Image="/client-side/images/products/iphone-x.jpg",SeoAlias = "may-tinh-bang-4",Price = 1000,Status = Status.Active,PromotionPrice = 1100},
                            new Product(){Name = "Máy tính bảng 5",DateCreated=DateTime.Now,Image="/client-side/images/products/iphone-x.jpg",SeoAlias = "may-tinh-bang-5",Price = 1000,Status = Status.Active,PromotionPrice = 1100},
                        }},
                    new ProductCategory() { Name="Máy tính xách tay",SeoAlias="may-tinh-xach-tay",ParentId = null,Status=Status.Active ,SortOrder=3,
                        Products = new List<Product>()
                        {
                            new Product(){Name = "Máy tính xách tay 1",DateCreated=DateTime.Now,Image="/client-side/images/products/iphone-x.jpg",SeoAlias = "may-tinh-xach-tay-1",Price = 1000,Status = Status.Active,PromotionPrice = 1100},
                            new Product(){Name = "Máy tính xách tay 2",DateCreated=DateTime.Now,Image="/client-side/images/products/iphone-x.jpg",SeoAlias = "may-tinh-xach-tay-2",Price = 1000,Status = Status.Active,PromotionPrice = 1100},
                            new Product(){Name = "Máy tính xách tay 3",DateCreated=DateTime.Now,Image="/client-side/images/products/iphone-x.jpg",SeoAlias = "may-tinh-xach-tay-3",Price = 1000,Status = Status.Active,PromotionPrice = 1100},
                            new Product(){Name = "Máy tính xách tay 4",DateCreated=DateTime.Now,Image="/client-side/images/products/iphone-x.jpg",SeoAlias = "may-tinh-xach-tay-4",Price = 1000,Status = Status.Active,PromotionPrice = 1100},
                            new Product(){Name = "Máy tính xách tay 5",DateCreated=DateTime.Now,Image="/client-side/images/products/iphone-x.jpg",SeoAlias = "may-tinh-xach-tay-5",Price = 1000,Status = Status.Active,PromotionPrice = 1100},
                        }},
                    new ProductCategory() { Name="Máy tính để bàn - PC",SeoAlias="may-tinh-de-ban-pc",ParentId = null,Status=Status.Active,SortOrder=4,
                        Products = new List<Product>()
                        {
                            new Product(){Name = "Máy tính để bàn - PC 1",DateCreated=DateTime.Now,Image="/client-side/images/products/iphone-x.jpg",SeoAlias = "may-tinh-de-ban-pc-1",Price = 1000,Status = Status.Active,PromotionPrice = 1100},
                            new Product(){Name = "Máy tính để bàn - PC 2",DateCreated=DateTime.Now,Image="/client-side/images/products/iphone-x.jpg",SeoAlias = "may-tinh-de-ban-pc-2",Price = 1000,Status = Status.Active,PromotionPrice = 1100},
                            new Product(){Name = "Máy tính để bàn - PC 3",DateCreated=DateTime.Now,Image="/client-side/images/products/iphone-x.jpg",SeoAlias = "may-tinh-de-ban-pc-3",Price = 1000,Status = Status.Active,PromotionPrice = 1100},
                            new Product(){Name = "Máy tính để bàn - PC 4",DateCreated=DateTime.Now,Image="/client-side/images/products/iphone-x.jpg",SeoAlias = "may-tinh-de-ban-pc-4",Price = 1000,Status = Status.Active,PromotionPrice = 1100},
                            new Product(){Name = "Máy tính để bàn - PC 5",DateCreated=DateTime.Now,Image="/client-side/images/products/iphone-x.jpg",SeoAlias = "may-tinh-de-ban-pc-5",Price = 1000,Status = Status.Active,PromotionPrice = 1100},
                        }},
                    new ProductCategory() { Name="Các loại phụ kiện",SeoAlias="cac-loai-phu-kien",ParentId = null,Status=Status.Active,SortOrder=1},
                    new ProductCategory() { Name="Photo & Camera",SeoAlias="photo-and-camera",ParentId = null,Status=Status.Active,SortOrder=1},
                    new ProductCategory() { Name="CD & License Key",SeoAlias="photo-and-camera",ParentId = null,Status=Status.Active,SortOrder=1},

                    };

                _context.ProductCategories.AddRange(listProductCategory);
            }

            if (!_context.SystemConfigs.Any(x => x.Id == "HomeTitle"))
            {
                _context.SystemConfigs.Add(new SystemConfig()
                {
                    Id = "HomeTitle",
                    Name = "Home's title",
                    Value1 = "Enterprise App Home",
                    Status = Status.Active
                });
            }
            if (!_context.SystemConfigs.Any(x => x.Id == "HomeMetaKeyword"))
            {
                _context.SystemConfigs.Add(new SystemConfig()
                {
                    Id = "HomeMetaKeyword",
                    Name = "Home Keyword",
                    Value1 = "Technology",
                    Status = Status.Active
                });
            }
            if (!_context.SystemConfigs.Any(x => x.Id == "HomeMetaDescription"))
            {
                _context.SystemConfigs.Add(new SystemConfig()
                {
                    Id = "HomeMetaDescription",
                    Name = "Home Description",
                    Value1 = "Home Enterprise App",
                    Status = Status.Active
                });
            }



            //save seed data to db
            await _context.SaveChangesAsync();
        }
    }
}