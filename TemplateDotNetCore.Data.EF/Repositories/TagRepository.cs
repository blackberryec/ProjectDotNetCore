﻿using System;
using System.Collections.Generic;
using System.Text;
using TemplateDotNetCore.Data.Entities;
using TemplateDotNetCore.Data.IRepositories;

namespace TemplateDotNetCore.Data.EF.Repositories
{
    public class TagRepository : EFRepository<Tag, string>, ITagRepository
    {
        public TagRepository(AppDbContext context) : base(context)
        {
        }
    }
}
