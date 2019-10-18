using System;
using System.Collections.Generic;
using System.Linq;

namespace SpareBank1
{
    public class Frame
    {
        public Frame(string frameString)
        {
            throws = frameString;
            numThrows = throws.Length;
            knockdowns = new List<int>
            {
                ProcessFirstThrow(throws[0])
            };
            if (numThrows > 1) {
                knockdowns.Add(ProcessSecondThrow(throws[1]));
            }
        }

        private int ProcessFirstThrow(char first)
        {
            if (first == 'X')
            {
                strike = true;
                return 10;
            }
            if (first == '-')
            {
                return 0;
            }
            return (int)Char.GetNumericValue(first);
        }

        private int ProcessSecondThrow(char second)
        {
            if (second == '/')
            {
                spare = true;
                return 10 - knockdowns[0];
            }
            if (second == '-')
            {
                return 0;
            }
            return (int)Char.GetNumericValue(second);
        }
        private string throws;

        public bool strike = false;
        public bool spare = false;
        public int numThrows;
        public List<int> knockdowns;        
    }

    public class Bowling
    {
        static public int CalculateScore(string rollSequence)
        {
            string throws = rollSequence.Replace(" ", "");
            string[] frameStrings = rollSequence.Split(" ");
            List<Frame> frames = new List<Frame>();
            foreach(string frameString in frameStrings)
            {
                frames.Add(new Frame(frameString));
            }

            int score = 0;
            for (int i = 0; i < 10; i++)
            {
                Frame frame = frames[i];
                if (frame.strike)
                {
                    score += CalculateStrike(frames, i);
                    continue;
                }
                if (frame.spare)
                {
                    score += 10 + frames[i + 1].knockdowns[0];
                    continue;
                }
                score += frame.knockdowns.Sum();
            }
            return score;
        }

        static public int CalculateStrike(List<Frame> frames, int i)
        {
            if (frames[i + 1].numThrows > 1)
            {
                return 10 + frames[i + 1].knockdowns.Sum();
            }
            else
            {
                return 10 + frames[i + 1].knockdowns[0] + frames[i + 2].knockdowns[0];
            }
        }
    }
}