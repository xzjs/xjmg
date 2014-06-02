using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace xjmg.Models
{
    [DisplayName("商品信息")]
    [DisplayColumn("Name")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("商品类别")]
        [Required]
        public virtual ProductCategory ProductCategory { get; set; }

        [DisplayName("商品名称")]
        [Required(ErrorMessage = "请输入商品名称")]
        [MaxLength(60, ErrorMessage = "商品名称不可超过60字")]
        public string Name { get; set; }

        [DisplayName("商品简介")]
        [Required(ErrorMessage = "请输入商品简介")]
        [MaxLength(250, ErrorMessage = "商品名称不可超过250字")]
        public string Description { get; set; }

        [DisplayName("商品价格")]
        [Required(ErrorMessage = "请输入商品售价")]
        [Range(0,99,ErrorMessage="商品售价必须介于0~99之间")]
        public double Price { get; set; }

        [DisplayName("上架时间")]
        [Description("如果不设置上架时间，代表此商品永不上架")]
        public DateTime? PublishOn { get; set; }
    }
}