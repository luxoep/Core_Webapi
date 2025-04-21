using Microsoft.AspNetCore.Mvc.Routing;

namespace IRouteTemplateProviderTest
{
    public class MyIRouteTemplateProviderAttribute : Attribute, IRouteTemplateProvider
    {
        public string Prefix { get; set; } = "My"; // 通过属性赋值
        public string? Name { get; set; }
        public string? Template
        {
            get
            {
                return $"{Prefix}/[controller]";
            }
        }
        public int? Order
        {
            get
            {
                return 1;
            }
        }
    }
}