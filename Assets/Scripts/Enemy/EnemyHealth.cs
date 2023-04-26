public class EnemyHealth : AbstractHealth
{
    public override void Die()
    {
        Destroy(gameObject);
    }
}
