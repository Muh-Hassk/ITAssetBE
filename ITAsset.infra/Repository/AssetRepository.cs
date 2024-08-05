using Dapper;
using ITAsset.core.Data;
using ITAsset.core.ICommon;
using ITAsset.core.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace ITAsset.infra.Repository
{
    public class AssetRepository : IAssetRepository
    {
        private readonly IDbContext _dbContext;

        public AssetRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsset(Asset asset)
        {

            var param = new DynamicParameters();
            param.Add("p_Brand", asset.Brand, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("p_SerialNumber", asset.SerialNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("p_WarrantyExpirationDate", asset.WarrantyExpirationDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            param.Add("p_Status", asset.Status, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.ExecuteAsync("AddITAsset", param, commandType: CommandType.StoredProcedure);


        }

        public async Task DeleteAsset(int id)
        {
            var param = new DynamicParameters();
            param.Add("p_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.ExecuteAsync("DeleteITAsset", param, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<Asset>> GetAllAssets()
        {
            var res = await _dbContext.Connection.QueryAsync<Asset>("GetAllAsset", commandType: CommandType.StoredProcedure);
            return res.ToList();
        }

        public async Task UpdateAsset(Asset asset)
        {
            var param = new DynamicParameters();
            param.Add("p_ID", asset.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("p_Brand", asset.Brand, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("p_SerialNumber", asset.SerialNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("p_WarrantyExpirationDate", asset.WarrantyExpirationDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            param.Add("p_Status", asset.Status, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.ExecuteAsync("UpdateITAsset", param, commandType: CommandType.StoredProcedure);
        }
    }
}