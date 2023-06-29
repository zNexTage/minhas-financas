using System;

namespace MinhasFinancas.Enum;

public class PaymentCategories {
        public string Value { get; set; }

        public static readonly PaymentCategories BANK_SLIP = new PaymentCategories {Value = "Boleto"};
        public static readonly PaymentCategories TRANSPORT = new PaymentCategories {Value = "Transporte"};
        public static readonly PaymentCategories FOOD = new PaymentCategories {Value = "Alimentação"};
        public static readonly PaymentCategories OTHERS = new PaymentCategories {Value = "Outros"};

        public static List<string> ToList(){
            return new List<string>{
                BANK_SLIP.Value,
                TRANSPORT.Value,
                FOOD.Value,
                OTHERS.Value
            };
        }
    }
