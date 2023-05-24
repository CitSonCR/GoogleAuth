using System;
using System.ComponentModel.DataAnnotations;

namespace ThirdPartyAuthTest.Models
{
	public class ErrorViewModel
	{
		public ErrorViewModel()
		{
		}
        [Key]
        public int Id { get; set; }
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}

