namespace Server.DTO
{
    /// <summary>
    /// DTO for representing grade statistics for a subject (minimum, maximum, and average grade)
    /// </summary>
    public class SubjectGradeStatisticsDto
    {
        /// <summary>
        /// Subject name
        /// </summary>
        public required string SubjectName { get; set; }

        /// <summary>
        /// Minimum grade for the subject
        /// </summary>
        public int MinGrade { get; set; }

        /// <summary>
        /// Maximum grade for the subject
        /// </summary>
        public int MaxGrade { get; set; }

        /// <summary>
        /// Average grade for the subject
        /// </summary>
        public double AverageGrade { get; set; }
    }
}
