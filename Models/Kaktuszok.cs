using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RESTAPI25032101.Models;

[PrimaryKey("Id")]
[Table("kaktuszok")]
public partial class Kaktuszok
{
    [Column("id")]
    public int Id { get; set; }

    [Column("koznapi_nev")]
    [StringLength(50)]
    [Unicode(false)]
    public string? KoznapiNev { get; set; }

    [Column("tudomanyos_nev")]
    [StringLength(50)]
    [Unicode(false)]
    public string? TudomanyosNev { get; set; }

    [Column("termesztesi_nehezseg")]
    public int? TermesztesiNehezseg { get; set; }

    [Column("vizigeny")]
    public int? Vizigeny { get; set; }

    [Column("fenyigeny")]
    public int? Fenyigeny { get; set; }
}
