﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Movies.API.Common;

public abstract class ApiControllerBase : ControllerBase
{
    private ISender _mediator;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}
