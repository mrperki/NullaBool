namespace NullaBool
{
    /// <summary>
    /// Generic NullaBool is even worse than regular NullaBool; we don't know why it exists.
    /// </summary>
    /// <typeparam name="T">A type that requires some extra NullaBool magic</typeparam>
    public class NullaBool<T> : NullaBool
    {
        /// <summary>
        /// The boring, default constructor, even more boring than the base.
        /// </summary>
        public NullaBool() : base() { }

        /// <summary>
        /// Another one of these, pretty dull. The overloads are way more interesting.
        /// </summary>
        /// <param name="set">the boolification</param>
        public NullaBool(bool set) : base(set) { }

        /// <summary>
        /// We have begrudgingly included one of these constructors. You're welcome.
        /// But seriously, the others on this class are way cooler.
        /// </summary>
        /// <param name="set">ugh, this thing</param>
        public NullaBool(bool? set) : base(set) { }

        /// <summary>
        /// Now we're talkin'. Go ahead and tee up your object with this contructor.
        /// </summary>
        /// <param name="obj"></param>
        public NullaBool(T obj) : base()
        {
            MagicItem = obj;
        }

        /// <summary>
        /// Sets your special object and brings a friendly bool along for the ride. Magic!
        /// </summary>
        /// <param name="obj">fun!</param>
        /// <param name="set">fun?</param>
        public NullaBool(T obj, bool set) : base(set)
        {
            MagicItem = obj;
        }

        /// <summary>
        /// We're not sure why you'd want to mess up your lovely object with a bool? but you're the boss.
        /// </summary>
        /// <param name="obj">cool</param>
        /// <param name="set">gross</param>
        public NullaBool(T obj, bool? set) : base(set)
        {
            MagicItem = obj;
        }

        /// <summary>
        /// An item that can harness the pure power of NullaBool
        /// </summary>
        public T MagicItem { get; set; }

        /// <summary>
        /// Go ahead and make this null, but be aware there are Magic consequences.
        /// </summary>
        public new void MakeNull()
        {
            base.MakeNull();

            NullMagic();
        }

        /// <summary>
        /// Assign a nullable bool value to NullaBool and you might see some Magic happen!
        /// </summary>
        /// <param name="assignment"></param>
        public new void Assign(bool? assignment)
        {
            base.Assign(assignment);

            NullMagic();
        }

        private void NullMagic()
        {
            if (IsNull)
            {
                MagicItem = default(T);
            }
        }
     }
}
