namespace Infrastructure
{
  public static class MathHelper
  {
    /// <summary>
    /// Выполняет нелинейную интерполяцию по формуле квадратичной кривой Безье.
    /// </summary>
    /// <param name="start">Стартовое значение.</param>
    /// <param name="middle">Среднее опорное значение.</param>
    /// <param name="end">Итоговое значение.</param>
    /// <param name="t">Шаг расчета. Может хранить значение от 0 до 1.</param>
    /// <returns>Значение по формуле квадратичной кривой Безье на на шагу t.</returns>
    public static float Bezier(float start, float middle, float end, float t)
    {
      if (t <= 0)
        return start;

      if (t >= 1)
        return end;

      var result = (start * ((1 - t) * (1 - t))) + (middle * 2 * t * (1 - t)) + (end * (t * t));
      return result;
    }
  }
}