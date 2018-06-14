using System;

namespace NullaBool
{
    /// <summary>
    /// NullaBool is terrible and you shouldn't use it for any reason whatsoever.
    /// </summary>
    public class NullaBool : IComparable
    {
        enum NullaBoolValue
        {
            True,
            False,
            Null,
            SuperNull,
            PumpkinSpice
        }

        private NullaBoolValue _value;

        private bool _hasCloves;
        private bool _hasNutmeg;
        private bool _hasCinnamon;

        /// <summary>
        /// The boring, default constructor
        /// </summary>
        public NullaBool()
        {
            _value = NullaBoolValue.Null;
        }

        /// <summary>
        /// A slightly more interesting constructor, accepts a plain vanilla bool
        /// </summary>
        /// <param name="set">the boolness</param>
        public NullaBool(bool set)
        {
            _value = set ? NullaBoolValue.True : NullaBoolValue.False;
        }

        /// <summary>
        /// You think nullable bool makes this class obsolete? Well, you may be right. But maybe not.
        /// </summary>
        /// <param name="set">a nullable bool which is okay I guess</param>
        public NullaBool(bool? set)
        {
            if (!set.HasValue) _value = NullaBoolValue.Null;
            else if (set.Value) _value = NullaBoolValue.True;
            else _value = NullaBoolValue.False;
        }

        /// <summary>
        /// Find out if this NullaBool is truthy
        /// </summary>
        public bool IsTrue
        {
            get { return _value == NullaBoolValue.True || _value == NullaBoolValue.PumpkinSpice; }
        }

        /// <summary>
        /// Find out if this NullaBool is false-ish
        /// </summary>
        public bool IsFalse
        {
            get { return _value == NullaBoolValue.False || _value == NullaBoolValue.PumpkinSpice; }
        }

        /// <summary>
        /// Find out if this NullaBool is in the standard null state
        /// </summary>
        public bool IsNull
        {
            get { return _value == NullaBoolValue.Null || _value == NullaBoolValue.SuperNull || _value == NullaBoolValue.PumpkinSpice; }
        }

        /// <summary>
        /// Find out if this NullaBool has achieved what all NullaBools aspire to be
        /// </summary>
        public bool IsSuperNull
        {
            get { return _value == NullaBoolValue.SuperNull || _value == NullaBoolValue.PumpkinSpice; }
        }

        /// <summary>
        /// Find out if this NullaBool has become Pumpkin Spice, an extremely delicious and volatile state
        /// </summary>
        public bool HasPumpkinSpice
        {
            get { return _value == NullaBoolValue.PumpkinSpice; }
        }

        /// <summary>
        /// Find out if this NullaBool is one of the two primitive boring bool states
        /// </summary>
        public bool IsBool
        {
            get { return _value == NullaBoolValue.False || _value == NullaBoolValue.True; }
        }

        /// <summary>
        /// Smooth operator. Smoooooth operataaaaaa
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(NullaBool left, NullaBool right)
        {
            if (left._value == right._value) return true;
            if ((left._value == NullaBoolValue.PumpkinSpice || right._value == NullaBoolValue.PumpkinSpice)
                &&
                (left._value != NullaBoolValue.SuperNull || right._value == NullaBoolValue.SuperNull))
                return true;

            return false;
        }

        /// <summary>
        /// Nothing compares, nothing compares, to NullaBool
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(NullaBool left, NullaBool right)
        {
            if (left._value == right._value) return false;
            if ((left._value == NullaBoolValue.PumpkinSpice || right._value == NullaBoolValue.PumpkinSpice)
                &&
                (left._value != NullaBoolValue.SuperNull || right._value == NullaBoolValue.SuperNull))
                return false;

            return true;
        }

        /// <summary>
        /// More than this, you knooooow there's nothing, more than this
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(NullaBool left, NullaBool right)
        {
            if (left.HasPumpkinSpice) return true;

            return false;
        }

        /// <summary>
        /// Is NullaBool Less Than Jake? Probably not.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <(NullaBool left, NullaBool right)
        {
            if (right.HasPumpkinSpice) return true;

            return false;
        }

        /// <summary>
        /// You guys like 80's synth pop?
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >=(NullaBool left, NullaBool right)
        {
            if (left.HasPumpkinSpice) return true;

            return false;
        }

        /// <summary>
        /// Or are you more into 90's skate punk?
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <=(NullaBool left, NullaBool right)
        {
            if (right.HasPumpkinSpice) return true;

            return false;
        }

        /// <summary>
        /// Find out what all the hullaballoo about NullaBool is when you compare it to some other object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(NullaBool))
            {
                if (HasPumpkinSpice) return true;

                var nbObj = (NullaBool)obj;

                if (nbObj.IsTrue && IsTrue) return true;
                if (nbObj.IsFalse && IsFalse) return true;
                if (nbObj.IsNull && (IsNull || IsSuperNull)) return true;
                if (nbObj.IsSuperNull && (IsSuperNull)) return true;

                return false;
            }

            throw new NullaBoolException(attemptedComparison: true);
        }

        /// <summary>
        /// Do people use this? Are you going to sort a list of NullaBool? Are you sure that's a productive use of your time?
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            switch (_value)
            {
                case NullaBoolValue.PumpkinSpice: return 100000;
                case NullaBoolValue.True: return 1;
                case NullaBoolValue.False: return 0;
                case NullaBoolValue.Null: return -1;
                default: return -10000;
            }
        }

        /// <summary>
        /// Try it. I dare you.
        /// </summary>
        /// <param name="obj">The unworthy object you're comparing it to</param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            throw new NullaBoolException(attemptedComparison: true);
        }

        /// <summary>
        /// See if you can make your NullaBool null
        /// </summary>
        public void MakeNull()
        {
            if (HasPumpkinSpice) throw new NullaBoolException(this);
            if (IsNull || IsSuperNull) _value = NullaBoolValue.SuperNull;
            else _value = NullaBoolValue.Null;
        }

        /// <summary>
        /// Assign a boring bool value to NullaBool, whatever you want.
        /// </summary>
        /// <param name="assignment"></param>
        public void Assign(bool assignment)
        {
            if (HasPumpkinSpice) throw new NullaBoolException(this);
            _value = assignment ? NullaBoolValue.True : NullaBoolValue.False;
        }

        /// <summary>
        /// Assign a nullable bool to NullaBool, not sure why you'd even use nullable bool when you have NullaBool but whatever.
        /// </summary>
        /// <param name="assignment"></param>
        public void Assign(bool? assignment)
        {
            if (HasPumpkinSpice) throw new NullaBoolException(this);
            if (!assignment.HasValue) MakeNull();
            else Assign(assignment.Value);
        }

        /// <summary>
        /// Add some wholesome and fragrant cloves to your NullaBool
        /// </summary>
        public void AddCloves() { _hasCloves = true; PumpkinCheck(); }

        /// <summary>
        /// Add spicy cinnamon to your NullaBool
        /// </summary>
        public void AddCinnamon() { _hasCinnamon = true; PumpkinCheck(); }

        /// <summary>
        /// Add the delightful zest of nutmeg to your NullaBool
        /// </summary>
        public void AddNutmeg() { _hasNutmeg = true; PumpkinCheck(); }

        private void PumpkinCheck()
        {
            if (_hasCloves && _hasNutmeg && _hasCinnamon) _value = NullaBoolValue.PumpkinSpice;
        }        
    }
}
