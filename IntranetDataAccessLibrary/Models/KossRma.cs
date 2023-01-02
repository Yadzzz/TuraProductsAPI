using System;
using System.Collections.Generic;

namespace IntranetDataAccessLibrary.Models;

public partial class KossRma
{
    public int Id { get; set; }

    public int KossModelId { get; set; }

    public string ProblemDescription { get; set; } = null!;

    public string Vendor { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? CoAddress { get; set; }

    public string StreetAddress { get; set; } = null!;

    public string Zipcode { get; set; } = null!;

    public string City { get; set; } = null!;

    public string? Phone { get; set; }

    public string Email { get; set; } = null!;

    public DateTime Date { get; set; }

    public bool Finished { get; set; }

    public string Receipt { get; set; } = null!;

    public string? CustomReply { get; set; }

    public int? ReplyMessageId { get; set; }

    public DateTime? ReplyDate { get; set; }

    public string Country { get; set; } = null!;

    public virtual KossHeadphoneModel KossModel { get; set; } = null!;

    public virtual KossRmaMessage? ReplyMessage { get; set; }
}
