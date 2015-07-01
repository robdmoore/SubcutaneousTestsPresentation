using System;

namespace SubcutaneousTestsPresentation.Domain
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = CombGuidGenerator.Generate();
        }

        public virtual Guid Id { get; protected set; }

        public override string ToString()
        {
            return string.Format("{{{0}:{1}}}", GetType().Name, Id);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType())
                return false;

            return ((Entity) obj).Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}