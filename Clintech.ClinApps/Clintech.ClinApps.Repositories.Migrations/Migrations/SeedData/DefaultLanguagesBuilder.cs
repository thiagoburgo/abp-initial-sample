﻿using System.Collections.Generic;
using System.Linq;
using Abp.Localization;
using Clintech.ClinApps.Repositories.DbContexts;

namespace Clintech.ClinApps.Repositories.Migrations.Migrations.SeedData
{
    public class DefaultLanguagesBuilder
    {
        public static List<ApplicationLanguage> InitialLanguages { get; private set; }

        private readonly ClinAppsDbContext _context;

        static DefaultLanguagesBuilder()
        {
            InitialLanguages = new List<ApplicationLanguage>
            {
                new ApplicationLanguage(null, "en", "English", "famfamfam-flag-gb"),
                new ApplicationLanguage(null, "tr", "Türkçe", "famfamfam-flag-tr"),
                new ApplicationLanguage(null, "zh-CN", "简体中文", "famfamfam-flag-cn"),
                new ApplicationLanguage(null, "pt-BR", "Português-BR", "famfamfam-flag-br"),
                new ApplicationLanguage(null, "es", "Español", "famfamfam-flag-es")
            };
        }

        public DefaultLanguagesBuilder(ClinAppsDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            CreateLanguages();
        }

        private void CreateLanguages()
        {
            foreach (var language in InitialLanguages)
            {
                AddLanguageIfNotExists(language);
            }
        }

        private void AddLanguageIfNotExists(ApplicationLanguage language)
        {
            if (_context.Languages.Any(l => l.TenantId == language.TenantId && l.Name == language.Name))
            {
                return;
            }

            _context.Languages.Add(language);

            _context.SaveChanges();
        }
    }
}
