﻿using DB.Models;
using DB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ICompanyService
    {
        public List<Company> ShowCompanies();

        public void AddCompany(CompanyRequest model);

    }

}