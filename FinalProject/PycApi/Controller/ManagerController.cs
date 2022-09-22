using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PycApi.Controller;


public class Manager
{
    public string Name { get; set; }
    public DateTime DOB { get; set; }
    public string Email { get; set; }
}

public abstract class FilterModelBase : ICloneable
{
    public String Term { get; set; }
    public int Page { get; set; }
    public int Limit { get; set; }

    public FilterModelBase()
    {
        this.Page = 1;
        this.Limit = 2;
    }

    public abstract object Clone();
}
public class SampleFilterModel : FilterModelBase
{
    public override object Clone()
    {
        var jsonString = JsonConvert.SerializeObject(this);
        return JsonConvert.DeserializeObject(jsonString, this.GetType());
    }
}
public class PagedCollectionResponse<T> where T : class
{
    public IEnumerable<T> Items { get; set; }
    public Uri NextPage { get; set; }
    public Uri PreviousPage { get; set; }
}
[NonController]
[ApiController]
[Route("api/nhb/[controller]")]
public class ManagerController : ControllerBase
{
    IEnumerable<Manager> managers = new List<Manager>() {
            new Manager() { Name = "Nancy Davolio", DOB = DateTime.Parse("1948-12-08"), Email = "nancy.davolio@test.com" },
            new Manager() { Name = "Andrew Fuller", DOB = DateTime.Parse("1952-02-19"), Email = "andrew.fuller@test.com" },
            new Manager() { Name = "Janet Leverling", DOB = DateTime.Parse("1963-08-30"), Email = "janet.leverling@test.com" },
            new Manager() { Name = "Margaret Peacock", DOB = DateTime.Parse("1937-09-19"), Email = "margaret.peacock@test.com" },
            new Manager() { Name = "Steven Buchanan", DOB = DateTime.Parse("1955-03-04"), Email = "steven.buchanan@test.com" },
            new Manager() { Name = "Michael Suyama", DOB = DateTime.Parse("1963-07-02"), Email = "michael.suyama@test.com" },
            new Manager() { Name = "Robert King", DOB = DateTime.Parse("1960-05-29"), Email = "robert.king@test.com" },
            new Manager() { Name = "Laura Callahan", DOB = DateTime.Parse("1958-01-09"), Email = "laura.callahan@test.com" },
            new Manager() { Name = "Anne Dodsworth", DOB = DateTime.Parse("1966-01-27"), Email = "anne.dodsworth@test.com" }
            };

    public ManagerController()
    {

    }


    [HttpGet]
    public ActionResult<PagedCollectionResponse<Manager>> Get([FromQuery] SampleFilterModel filter)
    {

        //Filtering logic  
        Func<SampleFilterModel, IEnumerable<Manager>> filterData = (filterModel) =>
        {
            return managers.Where(p => p.Name.StartsWith(filterModel.Term ?? String.Empty, StringComparison.InvariantCultureIgnoreCase))
            .Skip((filterModel.Page - 1) * filter.Limit)
            .Take(filterModel.Limit)
            .OrderBy(x => x.Name);
        };

        //Get the data for the current page  
        var result = new PagedCollectionResponse<Manager>();
        result.Items = filterData(filter);

        //Get next page URL string  
        SampleFilterModel nextFilter = filter.Clone() as SampleFilterModel;
        nextFilter.Page += 1;
        String nextUrl = filterData(nextFilter).Count() <= 0 ? null : this.Url.Action("Get", null, nextFilter, Request.Scheme);

        //Get previous page URL string  
        SampleFilterModel previousFilter = filter.Clone() as SampleFilterModel;
        previousFilter.Page -= 1;
        String previousUrl = previousFilter.Page <= 0 ? null : this.Url.Action("Get", null, previousFilter, Request.Scheme);

        result.NextPage = !String.IsNullOrWhiteSpace(nextUrl) ? new Uri(nextUrl) : null;
        result.PreviousPage = !String.IsNullOrWhiteSpace(previousUrl) ? new Uri(previousUrl) : null;

        return result;

    }



}
