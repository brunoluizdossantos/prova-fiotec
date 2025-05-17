namespace Application.DTOs;

public class InfoDengueDto
{
	public long? data_iniSE { get; set; }
	public long? SE { get; set; }
	public decimal? casos_est { get; set; }
	public decimal? casos_est_min { get; set; }
	public decimal? casos_est_max { get; set; }
	public long? casos { get; set; }
	public decimal? p_rt1 { get; set; }
	public decimal? p_inc100k { get; set; }
	public long? Localidade_id { get; set; }
	public int? nivel { get; set; }
	public long? id { get; set; }
	public string versao_modelo { get; set; } = String.Empty;
	public decimal? tweet { get; set; }
	public decimal? Rt { get; set; }
	public decimal? pop { get; set; }
	public decimal? tempmin { get; set; }
	public decimal? umidmax { get; set; }
	public long? receptivo { get; set; }
	public long transmissao { get; set; }
	public long? nivel_inc { get; set; }
	public decimal? umidmed { get; set; }
	public decimal umidmin { get; set; }
	public decimal? tempmed { get; set; }
	public decimal? tempmax { get; set; }
	public long? casprov { get; set; }
	public long? casprov_est { get; set; }
	public long? casprov_est_min { get; set; }
	public long? casprov_est_max { get; set; }
	public long? casconf { get; set; }
	public long	notif_accum_year { get; set; }
}
