namespace system4.DAL
{
    public class Constants
    {
        public static string AppStatuses(int status)
        {
            var statuses = new Dictionary<int, string>
            {
                [1] = "pending",
                [2] = "canceled",
                [3] = "no_show",
                [4] = "complete",
                [5] = "revisit",

                [10] = "doc_preview",
                [11] = "doc_checked",
                [12] = "doc_complete",

                [13] = "remote_app",
            };

            return statuses[status];
        }

        public static string DocStatuses(int status)
        {
            var statuses = new Dictionary<int, string>
            {
                [1] = "wait_for_payment",
                [2] = "payed",
                [3] = "in_consulate",
                [4] = "doc_ready",
                [5] = "delivering",
                [6] = "complete",
                [7] = "deleted",
                [8] = "returned_to_consulate",
                [9] = "received",
                [10] = "sent_to_HQ",
                [11] = "received_in_HQ",
                [12] = "sent_to_branch",
                [13] = "received_in_branch",
                [14] = "to_be_sent_to_branch",
                [15] = "temporary_in_HQ",
                [16] = "correction",

                [25] = "wait_for_fox",
                [26] = "received_from_fox",
                [27] = "delivering_by_fox",

                [30] = "request"
            };

            return statuses[status];
        }
    }
}
