using Microsoft.Extensions.Options;

namespace GhFrame.Api.Options;

[OptionsValidator]
public partial class ValidateJwtOptions : IValidateOptions<JwtOptions>;