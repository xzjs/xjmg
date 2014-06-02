using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace xjmg.Models
{
    [DisplayName("会员信息")]
    [DisplayColumn("Name")]
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("订单主文件")]
        [Required]
        public virtual OrderHeader OrderHeader { get; set; }

        [DisplayName("订购商品")]
        [Required]
        public Product Product { get; set; }

        [DisplayName("商品售价")]
        [Required(ErrorMessage = "请输入商品售价")]
        [Range(0, 100, ErrorMessage = "商品价格介于0~100元之间")]
        [Description("价格会有所变动")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [DisplayName("选购数量")]
        [Required]
        public int Amount { get; set; }
    }
}