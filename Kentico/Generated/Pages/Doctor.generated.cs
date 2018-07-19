//--------------------------------------------------------------------------------------------------
// <auto-generated>
//
//     This code was generated by code generator tool.
//
//     To customize the code use your own partial class. For more info about how to use and customize
//     the generated code see the documentation at http://docs.kentico.com.
//
// </auto-generated>
//--------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

using CMS;
using CMS.Base;
using CMS.Helpers;
using CMS.DataEngine;
using CMS.DocumentEngine.Types.Training;
using CMS.DocumentEngine;

[assembly: RegisterDocumentType(Doctor.CLASS_NAME, typeof(Doctor))]

namespace CMS.DocumentEngine.Types.Training
{
    /// <summary>
    /// Represents a content item of type Doctor.
    /// </summary>
    public partial class Doctor : TreeNode
    {
        #region "Constants and variables"

        /// <summary>
        /// The name of the data class.
        /// </summary>
        public const string CLASS_NAME = "Training.Doctor";


        /// <summary>
        /// The instance of the class that provides extended API for working with Doctor fields.
        /// </summary>
        private readonly DoctorFields mFields;

        #endregion


        #region "Properties"

        /// <summary>
        /// DoctorID.
        /// </summary>
        [DatabaseIDField]
        public int DoctorID
        {
            get
            {
                return ValidationHelper.GetInteger(GetValue("DoctorID"), 0);
            }
            set
            {
                SetValue("DoctorID", value);
            }
        }


        /// <summary>
        /// First name.
        /// </summary>
        [DatabaseField]
        public string DoctorFirstName
        {
            get
            {
                return ValidationHelper.GetString(GetValue("DoctorFirstName"), @"");
            }
            set
            {
                SetValue("DoctorFirstName", value);
            }
        }


        /// <summary>
        /// Last name.
        /// </summary>
        [DatabaseField]
        public string DoctorLastName
        {
            get
            {
                return ValidationHelper.GetString(GetValue("DoctorLastName"), @"");
            }
            set
            {
                SetValue("DoctorLastName", value);
            }
        }


        /// <summary>
        /// Doctor degree.
        /// </summary>
        [DatabaseField]
        public string DoctorDegree
        {
            get
            {
                return ValidationHelper.GetString(GetValue("DoctorDegree"), @"");
            }
            set
            {
                SetValue("DoctorDegree", value);
            }
        }


        /// <summary>
        /// Photo.
        /// </summary>
        [DatabaseField]
        public Guid DoctorImage
        {
            get
            {
                return ValidationHelper.GetGuid(GetValue("DoctorImage"), Guid.Empty);
            }
            set
            {
                SetValue("DoctorImage", value);
            }
        }


        /// <summary>
        /// Doctor specialty.
        /// </summary>
        [DatabaseField]
        public string DoctorSpecialty
        {
            get
            {
                return ValidationHelper.GetString(GetValue("DoctorSpecialty"), @"");
            }
            set
            {
                SetValue("DoctorSpecialty", value);
            }
        }


        /// <summary>
        /// Bio.
        /// </summary>
        [DatabaseField]
        public string DoctorBio
        {
            get
            {
                return ValidationHelper.GetString(GetValue("DoctorBio"), @"");
            }
            set
            {
                SetValue("DoctorBio", value);
            }
        }


        /// <summary>
        /// Emergency shift.
        /// </summary>
        [DatabaseField]
        public int DoctorEmergencyShift
        {
            get
            {
                return ValidationHelper.GetInteger(GetValue("DoctorEmergencyShift"), 0);
            }
            set
            {
                SetValue("DoctorEmergencyShift", value);
            }
        }


        /// <summary>
        /// Gets an object that provides extended API for working with Doctor fields.
        /// </summary>
        [RegisterProperty]
        public DoctorFields Fields
        {
            get
            {
                return mFields;
            }
        }


        /// <summary>
        /// Provides extended API for working with Doctor fields.
        /// </summary>
        [RegisterAllProperties]
        public partial class DoctorFields : AbstractHierarchicalObject<DoctorFields>
        {
            /// <summary>
            /// The content item of type Doctor that is a target of the extended API.
            /// </summary>
            private readonly Doctor mInstance;


            /// <summary>
            /// Initializes a new instance of the <see cref="DoctorFields" /> class with the specified content item of type Doctor.
            /// </summary>
            /// <param name="instance">The content item of type Doctor that is a target of the extended API.</param>
            public DoctorFields(Doctor instance)
            {
                mInstance = instance;
            }


            /// <summary>
            /// DoctorID.
            /// </summary>
            public int ID
            {
                get
                {
                    return mInstance.DoctorID;
                }
                set
                {
                    mInstance.DoctorID = value;
                }
            }


            /// <summary>
            /// First name.
            /// </summary>
            public string FirstName
            {
                get
                {
                    return mInstance.DoctorFirstName;
                }
                set
                {
                    mInstance.DoctorFirstName = value;
                }
            }


            /// <summary>
            /// Last name.
            /// </summary>
            public string LastName
            {
                get
                {
                    return mInstance.DoctorLastName;
                }
                set
                {
                    mInstance.DoctorLastName = value;
                }
            }


            /// <summary>
            /// Doctor degree.
            /// </summary>
            public string Degree
            {
                get
                {
                    return mInstance.DoctorDegree;
                }
                set
                {
                    mInstance.DoctorDegree = value;
                }
            }


            /// <summary>
            /// Photo.
            /// </summary>
            public DocumentAttachment Image
            {
                get
                {
                    return mInstance.GetFieldDocumentAttachment("DoctorImage");
                }
            }


            /// <summary>
            /// Doctor specialty.
            /// </summary>
            public string Specialty
            {
                get
                {
                    return mInstance.DoctorSpecialty;
                }
                set
                {
                    mInstance.DoctorSpecialty = value;
                }
            }


            /// <summary>
            /// Bio.
            /// </summary>
            public string Bio
            {
                get
                {
                    return mInstance.DoctorBio;
                }
                set
                {
                    mInstance.DoctorBio = value;
                }
            }


            /// <summary>
            /// Emergency shift.
            /// </summary>
            public int EmergencyShift
            {
                get
                {
                    return mInstance.DoctorEmergencyShift;
                }
                set
                {
                    mInstance.DoctorEmergencyShift = value;
                }
            }
        }

        #endregion


        #region "Constructors"

        /// <summary>
        /// Initializes a new instance of the <see cref="Doctor" /> class.
        /// </summary>
        public Doctor() : base(CLASS_NAME)
        {
            mFields = new DoctorFields(this);
        }

        #endregion
    }
}