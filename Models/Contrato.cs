namespace ApiContratosDockerK8s.Models;

public class Contrato
{
    public int Id { get; set; }
    public string? Numero { get; set; }
    public string? Cliente { get; set; }
    public decimal Valor { get; set; }
    public DateTime DataAssinatura { get; set; }
}
