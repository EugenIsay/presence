﻿using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Presence.Api.Request
{
    public class SubjectRequest
    {
        public int Id { get; set; }
        public int Semestr {  get; set; }
    }
}
