using System;
using System.Collections.Generic;

namespace Nencer.Models;

/// <summary>
/// Chi tiết user
/// </summary>
public partial class UserDetail
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int? JobId { get; set; }

    public string? Description { get; set; }

    public string? Address { get; set; }

    public string? IdNumber { get; set; }

    public DateTime? ExpireAt { get; set; }

    public int? CityId { get; set; }

    public string? CountryCode { get; set; }

    public string? Nationality { get; set; }

    public string? Religion { get; set; }

    public int? Married { get; set; }

    public int? Children { get; set; }

    public int? PartyMember { get; set; }

    public string? FatherInfo { get; set; }

    public string? MotherInfo { get; set; }

    public string? HusbandWifeInfo { get; set; }

    public string? ChildrenInfo { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
