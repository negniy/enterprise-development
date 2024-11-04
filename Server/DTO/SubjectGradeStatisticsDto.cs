namespace Server.DTO
{
    /// <summary>
    /// DTO для представления статистики оценок по предмету (минимальный, максимальный и средний балл).
    /// </summary>
    public class SubjectGradeStatisticsDto
    {
        /// <summary>
        /// Название предмета
        /// </summary>
        public required string SubjectName { get; set; }

        /// <summary>
        /// Минимальный балл по предмету
        /// </summary>
        public int MinGrade { get; set; }

        /// <summary>
        /// Максимальный балл по предмету
        /// </summary>
        public int MaxGrade { get; set; }

        /// <summary>
        /// Средний балл по предмету
        /// </summary>
        public double AverageGrade { get; set; }
    }
}
