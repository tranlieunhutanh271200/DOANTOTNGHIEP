using System.Linq;

namespace Service.Core.Models.Courses
{
    public class MultichoiceQuestion : Question
    {
        public override bool CheckAnwer(Answer answer)
        {
            var foundAnswer = Answers.FirstOrDefault(ans => ans.Id == answer.Id);
            if (foundAnswer == null)
            {
                return false;
            }
            return true;
        }
    }
}
