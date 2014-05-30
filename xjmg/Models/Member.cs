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
    public class Member
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("会员账号")]
        [Required(ErrorMessage = "请输入email地址")]
        [Description("我们直接以email当成会员登录的账号")]
        [MaxLength(250, ErrorMessage = "email地址长度无法超过250字")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("会员密码")]
        [Required(ErrorMessage = "请输入密码")]
        [Description("密码将以SHA1进行哈希运算，通过SHA1哈希运算后的结果转为HEX表示法的字符串长度皆为40个字符")]
        [MaxLength(40, ErrorMessage = "密码不得超过250字")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("中文姓名")]
        [Required(ErrorMessage = "请输入中文姓名")]
        [Description("暂时不给老外卖")]
        [MaxLength(5, ErrorMessage = "中文姓名不可超过5字")]
        public string Name { get; set; }

        [DisplayName("网络昵称")]
        [Required(ErrorMessage = "请输入网络昵称")]
        [MaxLength(10, ErrorMessage = "无法超过10字")]
        public string Nickname { get; set; }

        [DisplayName("会员注册时间")]
        public DateTime RegisterOn { get; set; }

        [DisplayName("会员启用认证码")]
        [Description("当AuthCode扥与Null则代表此会员已经通过Email有效性验证")]
        [MaxLength(36, ErrorMessage = "email地址长度无法超过250字")]
        public string AuthCode { get; set; }
    }
}