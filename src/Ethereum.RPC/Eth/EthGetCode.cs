

using System;
using System.Threading.Tasks;
using edjCase.JsonRpc.Client;
using edjCase.JsonRpc.Core;
using Ethereum.RPC.Eth;
using Ethereum.RPC.Generic;
using RPCRequestResponseHandlers;

namespace Ethereum.RPC
{

    ///<Summary>
       /// eth_getCode
/// 
/// Returns code at a given address.
/// 
/// Parameters
/// 
/// DATA, 20 Bytes - address
/// QUANTITY|TAG - integer block number, or the string "latest", "earliest" or "pending", see the default block parameter
/// params: [
///    '0xa94f5374fce5edbc8e2a8697c15331677e6ebf0b',
///    '0x2'  // 2
/// ]
/// Returns
/// 
/// DATA - the code from the given address.
/// 
/// Example
/// 
///  Request
/// curl -X POST --data '{"jsonrpc":"2.0","method":"eth_getCode","params":["0xa94f5374fce5edbc8e2a8697c15331677e6ebf0b", "0x2"],"id":1}'
/// 
///  Result
/// {
///   "id":1,
///   "jsonrpc": "2.0",
///   "result": "0x600160008035811a818181146012578301005b601b6001356025565b8060005260206000f25b600060078202905091905056"
/// }    
    ///</Summary>
    public class EthGetCode : RpcRequestResponseHandler<string>
        {
            public EthGetCode() : base(ApiMethods.eth_getCode.ToString()) { }

            public async Task<string> SendRequestAsync(RpcClient client, string address, BlockParameter block, string id = Constants.DEFAULT_REQUEST_ID)
            {
                return await base.SendRequestAsync(client, id, address, block);
            }

            public async Task<string> SendRequestAsync(RpcClient client, string address, string id = Constants.DEFAULT_REQUEST_ID)
            {
                return await base.SendRequestAsync(client, address, BlockParameter.CreateLatest(), id);
            }

        public RpcRequest BuildRequest(string address, BlockParameter block, string id = Constants.DEFAULT_REQUEST_ID)
            {
                return base.BuildRequest(id, address, block);
            }
        }

    }
