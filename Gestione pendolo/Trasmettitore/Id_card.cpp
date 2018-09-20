#include "Id_card.h"

void Id_card::vts()
{
  Serial.write(major_release_id);
  Serial_util::int16(update_id);
  Serial.write(version_id);
}
