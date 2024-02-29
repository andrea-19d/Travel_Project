﻿using BusinessLogic.Core;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Enums;
using Domain.Entities.Res;
using Domain.Entities.User;
using Domain.Entities.User.Global;
using Domain.Entities.Product;

namespace BusinessLogic
{
    class ProductBL : UserApi, IProduct
    {
        public ProductDetail GetProductDetail(int id)
        {
            return GetProdUser(id);
        }
    }
}
