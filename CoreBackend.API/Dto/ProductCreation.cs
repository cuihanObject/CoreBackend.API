﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CoreBackend.API.Dto
{
    public class ProductCreation
    {
        [Display(Name="产品名称")]
        [Required(ErrorMessage ="{0}是必填项")]
        [StringLength(10,MinimumLength =2,ErrorMessage ="{0}的长度应不小于{2}，不大于{1}")]
        public string Name { get; set; }

        [Display(Name="价格")]
        [Range(0,Double.MaxValue,ErrorMessage ="{0}的值必须大于{1}")]
        public float Price { get; set; }

        [Display(Name = "描述")]
        [MaxLength(100, ErrorMessage = "{0}的长度不可以超过{1}")]
        public string Description { get; set; }
    }
}
