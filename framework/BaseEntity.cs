using log4net;
using log4net.Config;

namespace demo.framework
{
    public class BaseEntity
    {
        protected static ILog Log;

        protected BaseEntity()
        {
            XmlConfigurator.Configure();
            Log = LogManager.GetLogger(typeof(BaseEntity));
        }

        public void LogStep(int step, string message)
        {
            Log.Info(string.Format("----------[ Step {0} ]: {1}", step, message));
        }

        protected virtual string GetElementType()
        {
            throw new System.NotImplementedException();
        }

    }
}
