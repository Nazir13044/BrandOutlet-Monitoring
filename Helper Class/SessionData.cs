using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCMS_MAIN.HelperClass
{
    public class SessionData
    {
        public  SessionData(long id,string userName)
        {
            Id = id;
            Name = userName;

        }
            public long Id { get; set; }
            public string Name { get; set; }
    
             public static Dictionary<int, SessionData> GetSessionValues()
            {
                var sessionData = new Dictionary<int, SessionData>();

                if (HttpContext.Current.Session["BrandLoginUserId"] == null)
                {
                    var akSessionData = new SessionData(0, "UserId");
                    sessionData.Add(1, akSessionData);
                }
                else
                {
                    var aSessionData = new SessionData(long.Parse(HttpContext.Current.Session["BrandLoginUserId"].ToString()), "UserId");
                    sessionData.Add(1, aSessionData);
                }

                if (HttpContext.Current.Session["BrandLoginUserName"] == null)
                {
                    var akSessionData = new SessionData(0, "UserName");
                    sessionData.Add(2, akSessionData);
                }
                else
                {
                    var aSessionData = new SessionData(long.Parse(HttpContext.Current.Session["BrandLoginUserName"].ToString()), "UserName");
                    sessionData.Add(2, aSessionData);
                }

                if (HttpContext.Current.Session["BrandLoginUserEmployeeId"] == null)
                {
                    var akSessionData = new SessionData(0, "EmployeeId");
                    sessionData.Add(3, akSessionData);
                }
                else
                {
                    var aSessionData = new SessionData(long.Parse(HttpContext.Current.Session["BrandLoginUserEmployeeId"].ToString()), "EmployeeId");
                    sessionData.Add(3, aSessionData);
                }

                if (HttpContext.Current.Session["BrandLoginEmployeeMobile"] == null)
                {
                    var akSessionData = new SessionData(0, "Mobile");
                    sessionData.Add(4, akSessionData);
                }
                else
                {
                    var aSessionData = new SessionData(long.Parse(HttpContext.Current.Session["BrandLoginEmployeeMobile"].ToString()), "Mobile");
                    sessionData.Add(4, aSessionData);
                }


                return sessionData;
            }


             
        }


    }
