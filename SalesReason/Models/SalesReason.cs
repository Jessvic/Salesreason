using System.ComponentModel.DataAnnotations;

namespace SalesReason.Models;
public class SalesReason
{
    public int SalesReasonID { get; set; }
    public string Name { get; set; }
    public string ReasonType { get; set; }
}