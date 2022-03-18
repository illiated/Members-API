using RestSharp;

int totalResultsCount = 0;

List<Member> members = new List<Member>();

int skipTotal = 0;

int take = 20;

var client = new RestClient("https://members-api.parliament.uk");

do
{
    var requestURL = $"api/Members/Search?IsCurrentMember=true&skip={skipTotal}&take={take}&House=1";
    var result = await client.GetAsync<MembersAPIResult>(new RestRequest(requestURL)); // Set the Path to the url
    totalResultsCount = result.TotalResults;

    members.AddRange(result.Items.Select(i => i.Value));

    skipTotal += take;
    
}
while (members.Count < totalResultsCount);




// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class LatestParty
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Abbreviation { get; set; }
    public string BackgroundColour { get; set; }
    public string ForegroundColour { get; set; }
    public bool IsLordsMainParty { get; set; }
    public bool IsLordsSpiritualParty { get; set; }
    public int? GovernmentType { get; set; }
    public bool IsIndependentParty { get; set; }
}

public class MembershipStatus
{
    public bool StatusIsActive { get; set; }
    public string StatusDescription { get; set; }
    public object StatusNotes { get; set; }
    public int StatusId { get; set; }
    public DateTime StatusStartDate { get; set; }
}

public class LatestHouseMembership
{
    public string MembershipFrom { get; set; }
    public int MembershipFromId { get; set; }
    public int House { get; set; }
    public DateTime MembershipStartDate { get; set; }
    public object MembershipEndDate { get; set; }
    public object MembershipEndReason { get; set; }
    public object MembershipEndReasonNotes { get; set; }
    public object MembershipEndReasonId { get; set; }
    public MembershipStatus MembershipStatus { get; set; }
}

public class Member
{
    public int Id { get; set; }
    public string NameListAs { get; set; }
    public string NameDisplayAs { get; set; }
    public string NameFullTitle { get; set; }
    public string NameAddressAs { get; set; }
    public LatestParty LatestParty { get; set; }
    public string Gender { get; set; }
    public LatestHouseMembership LatestHouseMembership { get; set; }
    public string ThumbnailUrl { get; set; }
}

public class Link
{
    public string Rel { get; set; }
    public string Href { get; set; }
    public string Method { get; set; }
}

public class Item
{
    public Member Value { get; set; }
    public List<Link> Links { get; set; }
}

public class MembersAPIResult
{
    public List<Item> Items { get; set; }
    public int TotalResults { get; set; }
    public string ResultContext { get; set; }
    public int Skip { get; set; }
    public int Take { get; set; }
    public List<Link> Links { get; set; }
}

