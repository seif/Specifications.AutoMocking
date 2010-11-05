﻿namespace Xunit.Specifications.AutoMocking.Rhino
{
    using System;
    using global::Specifications.AutoMocking;
    using global::Specifications.AutoMocking.Rhino;


    public abstract class Specification<TSubject> : Specification<TSubject, TSubject>
    {
    }
    /// <summary>
    /// base class for writing specs using xunit with the subject dependencis mocked with Rhino.Mocks
    /// more info about the specification implementation at http://flux88.com/blog/the-transition-from-tdd-to-bdd/. 
    /// </summary>
    public abstract class Specification<TContract, TSubject> : 
        Specification<TContract, TSubject, RhinoMocksMockFactory>, 
        IUseFixture<object>
        where TSubject : TContract
    {
        #region IUseFixture<object> Members

        public void SetFixture(object unused)
        {
            try
            {
                EstablishContext();

                When();
            }
            catch (Exception e)
            {
                ExceptionThrown = e;
            }
        }

        #endregion

        protected Exception ExceptionThrown { get; set; }

        protected abstract void EstablishContext();

        protected abstract void When();
    }
}