using ITAsset.core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ITAsset.core.IRepository
{
    public interface IAssetRepository
    {
        public Task<List<Asset>> GetAllAssets();

        Task CreateAsset(Asset asset);

        Task UpdateAsset(Asset asset);

        Task DeleteAsset(int id);



    }
}
