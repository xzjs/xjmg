using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace xjmg.Models
{
    [DisplayName("会员信息")]
    [DisplayColumn("Name")]
    public class OrderHeader
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("订购会员")]
        [Required]
        public Member Member { get; set; }

        [DisplayName("收件人姓名")]
        [Required(ErrorMessage = "请输入收件人姓名")]
        [Description("订购会员不一定是收到商品的人")]
        [MaxLength(40, ErrorMessage = "收件人姓名长度无法超过40字")]
        public string ContantName { get; set; }

        [DisplayName("联络电话")]
        [Required(ErrorMessage = "请输入联络电话")]
        [MaxLength(25, ErrorMessage = "联络电话长度无法超过25字")]
        [DataType(DataType.PhoneNumber)]
        public string ContactPhoneNo { get; set; }

        [DisplayName("递送地址")]
        [Required(ErrorMessage = "请输入宿舍号")]
        public string ContantAddress { get; set; }

        [DisplayName("订单金额 ")]
        [Required]
        [Description("订单金额可能受到商品折扣异动价格")]
        [DataType(DataType.Currency)]
        public double TotalPrice { get; set; }

        [DisplayName("订单备注")]
        [DataType(DataType.MultilineText)]
        public string Memo { get; set; }

        [DisplayName("订购时间")]
        public DateTime BuyOn { get; set; }

        [NotMapped]
        public string DisplayName
        {
            get { return this.Member.Name + "于" + this.BuyOn + "订购的商品"; }
        }
    }
}