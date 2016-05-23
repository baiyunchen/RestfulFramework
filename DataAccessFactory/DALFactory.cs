using DataAccess;
using IDataAccess;

namespace DataAccessFactory
{
    public static class DALFactory
    {
        private static ApplicationDal _applicationDal;
        public static IApplicationDal ApplicationDal()
        {
            return _applicationDal ?? (_applicationDal = new ApplicationDal());
        }

        private static CustomerDal _customerDal;
        public static ICustomerDal CustomerDal()
        {
            return  _customerDal??(_customerDal=new CustomerDal());
        }

        private static IOAuthDal _oAuthDal;
        public static IOAuthDal OAuthDal()
        {
            return _oAuthDal ?? (_oAuthDal = new OAuthDal());
        }
    }
}
