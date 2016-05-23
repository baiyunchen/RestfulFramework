namespace RestfulFramework.Models
{
    public class ReturnMessage<T>
    {
        public ReturnMessage(bool success, T returnObj,string desc)
        {
            this.Success = success;
            this.ReturnObj = returnObj;
            this.Description = desc;
        }

        public ReturnMessage(T returnObj,bool success=true)
        {
            this.Success = success;
            this.ReturnObj = returnObj;
        }

        public ReturnMessage(string desc)
        {
            this.Success = false;
            this.Description = desc;
        }
        public ReturnMessage()
        {

        }
        public bool Success { get; set; }
        public T ReturnObj { get; set; }
        public string Description { get; set; }

        public static ReturnMessage<T> ErrorMsg(string desc)
        {
            return new ReturnMessage<T>
            {
                Success = false,
                Description = desc
            };
        }
        public static ReturnMessage<T> SuccessMsg(T returnObj)
        {
            return new ReturnMessage<T>
            {
                Success = true,
                ReturnObj = returnObj
            };
        }
    }

}