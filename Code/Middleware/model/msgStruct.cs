using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace model
{
    [DataContract]
    public class MsgStruct
    {
        [DataMember]
        public bool statutOp = true;

        [DataMember]
        public string info = "";

        [DataMember]
        public object[] data;

        [DataMember]
        public string operationName = "";

        [DataMember]
        public string tokenApp = "";

        [DataMember]
        public string tokenUser = "";

        [DataMember]
        public string appVersion = "1.0";

        [DataMember]
        public string operationVersion = "1.0";


        /*
        public bool getStatutOp() { return this.statutOp; }
        public string getInfo() { return this.info; }
        public object[] getData() { return this.data; }
        public string getOperationName() { return this.operationName; }
        public string getTokenApp() { return this.tokenApp; }
        public string getTokenUser() { return this.tokenUser; }
        public string getAppVersion() { return this.appVersion; }
        public string getOperationVersion() { return this.operationVersion; }

        public void setStatutOp(bool statutOp) { this.statutOp = statutOp; }
        public void setInfo(string info) { this.info = info; }
        public void setData(object[] data) { this.data = data; }

        public void setOperationName(string operationName) { this.operationName = operationName; }
        public void setTokenApp(string tokenApp) { this.tokenApp = tokenApp; }
        public void setTokenUser(string tokenUser) { this.tokenUser = tokenUser; }
        public void setAppVersion(string appVersion) { this.appVersion = appVersion; }
        public void setOperationVersion(string operationVersion) { this.operationVersion = operationVersion; }

        public msgStruct() { } */
    }
}
