using Microsoft.AspNetCore.Routing;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

public class PhoneNumberRouteConstraint : IRouteConstraint
{
    private static readonly Regex _regex = new Regex(@"^\+?[0-9]{11}$");
    public string ErrorMessage { get; set; } = "手机号有误";
    public bool Match(
        HttpContext? httpContext,
        IRouter? route,
        string routeKey,
        RouteValueDictionary values,
        RouteDirection routeDirection)
    {
        if (!values.TryGetValue(routeKey, out var routeValue))
        {
            return false;
        }

        string? routeValueString = Convert.ToString(routeValue, CultureInfo.InvariantCulture);

        return _regex.IsMatch(routeValueString);
    }
}