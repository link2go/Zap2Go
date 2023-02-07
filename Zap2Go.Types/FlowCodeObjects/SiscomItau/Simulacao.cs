using System.Collections.Generic;

namespace Zap2Go.Types.FlowCodeObjects.SiscomItau
{
    public class Contrato
    {
        public string nome_produto { get; set; }
        public double saldo_atraso { get; set; }
        public string id_contrato { get; set; }
        public string numero_contrato { get; set; }
        public List<object> parcelas { get; set; }
        public List<object> titulos { get; set; }
        public List<object> garantias { get; set; }
        public string codigo_produto { get; set; }
        public string bordero { get; set; }
        public double perc_desconto { get; set; }
        public string taxa_contrato { get; set; }
        public string dias_atraso { get; set; }
        public double valor_original { get; set; }
    }

    public class Grupo
    {
        public string identificador { get; set; }
        public double valor_original { get; set; }
        public double valor_simulacao { get; set; }
        public string data_vencimento_minimo { get; set; }
        public string data_vencimento_maximo { get; set; }
        public string data_vencimento { get; set; }
        public object valor_entrada_maxima { get; set; }
        public object valor_entrada_minima { get; set; }
        public object valor_parcela_minima { get; set; }
        public List<Contrato> contratos { get; set; }
        public List<OpcoesPagamento> opcoesPagamento { get; set; }
        public string id_simulacao { get; set; }
    }

    public class OpcoesPagamento
    {
        public double valor_entrada { get; set; }
        public object valor_parcela { get; set; }
        public object numero_parcelas { get; set; }
        public double valor_total { get; set; }
        public object id_plano { get; set; }
        public double perc_desconto { get; set; }
        public double valor_desconto { get; set; }
        public double valor_pagar { get; set; }
    }

    public class Simulacao
    {
        public string name { get; set; }
        public string id_jornada { get; set; }
        public List<Grupo> grupos { get; set; }
        public string first_name { get; set; }
    }


}
