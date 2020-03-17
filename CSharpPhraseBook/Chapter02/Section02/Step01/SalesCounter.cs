// List 2-21

using System;
using System.Collections.Generic;

namespace SalesCalculator {

    // List 2-16
    // 売り上げ集計クラス
    public class SalesCounter {

        private List<Sale> _sales;

        // コンストラクタ
        public SalesCounter(List<Sale> sales) {
            _sales = sales;
        }

        // List 2-17
        // 店舗別売り上げを求める
        public Dictionary<string, int> GetPerStoreSales() {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (Sale sale in _sales) {
                if (dict.ContainsKey(sale.ShopName))
                    dict[sale.ShopName] += sale.Amount;
                else
                    dict[sale.ShopName] = sale.Amount;
            }
            return dict;
        }

    }
}
