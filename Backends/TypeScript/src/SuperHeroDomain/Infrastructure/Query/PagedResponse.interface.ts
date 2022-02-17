export interface IPagedResponse{
    /// <summary>
        /// Indicates the current page number
        /// </summary>
        current_page: number;

        /// <summary>
        /// Indicates how many pages are available
        /// </summary>
        page_count: number;

        /// <summary>
        /// Number of items returned per page
        /// </summary>
        page_size: number;

        /// <summary>
        /// Number of all items available
        /// </summary>
        total_items: number;
}