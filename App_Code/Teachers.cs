using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Xml.Linq;

/// <summary>
/// Summary description for About
/// </summary>
public abstract class Teacher : System.Web.WebPages.WebPage
{
    private XElement teacher;
    private string id;

    public Teacher()
    {
        LoadItemById(null);
    }

    public void LoadItemById(HttpContextBase context)
    {
        string _id = "ma"; // "hn"; // "ok"; // "szgm"; // "hh"; // "ga"; // "hn"; //"hf"; // "gyp";// "hf"; "hv";
        id = HttpContext.Current.Request.QueryString["id"] ?? _id;
        GetItemById(id);
    }

    public void GetItemById(string id)
    { 
        if (teacher == null)
        {
            XDocument xml = XDocument.Load(HostingEnvironment.MapPath("~/teachers.xml"));
            teacher = (from o in xml.Root.Elements() where o.HasAttributes && o.Attribute("id").Value == id select o).FirstOrDefault();
        }
    }

    private string GetValue(string id, bool childnodes=false)
    {
        return teacher != null ? (childnodes ? teacher.Element(id).ToString().Replace("\r\n", " ").Replace("  ", "").Replace("\n", "") : teacher.Element(id).Value).Replace("\r\n", " ").Replace("  ", "").Replace("\n", "") : "not found";
    }

    private string GetNodes(string node, string id)
    {
        if (teacher != null)
        {
            var iset = teacher.Element(node).Elements().Where(o => o.Attribute("type").Value == id);
            if (iset != null &&iset.Count()>0)
            {
                var outp = iset.Select(o => o.ToString()).FirstOrDefault().Trim().Replace("\r\n", " ").Replace("  ", "").Replace("\n", "");
                return outp;
            }
        }
        return "";
    }

    public string Id { get { return id; } }
    public string Name { get { return GetValue("name"); } }

    public string Img { get { return GetValue("img"); } }

    public string Bio { get { return GetValue("bio", true); } }
    public string YoutubeQuery { get { return GetValue("youtube_query"); } }
    public string MtmtAuthorid { get { return GetValue("mtmt_authorid"); } }
    public string ScholarQuery { get { return GetValue("scholar_query"); } }
    public string AcademiaEduUrl { get { return GetValue("academiaedu_url"); } }

    public string OfficeHours { get { return GetValue("office_hours"); } }
    public string Email { get { return GetValue("email"); } }
    public string Telephone { get { return GetValue("telephone"); } }
    public string PostalAddress { get { return GetValue("postal_address"); } }

    public List<string> Interests { get { return teacher != null ? teacher.Element("interests").Elements().Select(o=>o.Value).ToList<string>() : new List<string>(); } }

    public string Publications { get { return GetNodes("publications", "publication"); } }

    public string Publications_Books { get { return GetNodes("publications", "book"); } }

    public string Publications_Conference { get { return GetNodes("publications", "conference"); } }

    public string Publications_SemiAuthor { get { return GetNodes("publications", "semiauthor"); } }

    public string Publications_OtherWorks { get { return GetNodes("publications", "otherworks"); } }

    public string Publications_OtherClasses { get { return GetNodes("publications", "otherclasses"); } }
}